import {Component, OnInit} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {MatTableDataSource} from '@angular/material/table';
import {MatSnackBar} from "@angular/material/snack-bar";
import {SnackAlertComponent} from "../../snack-alert/snack-alert.component";
import {IResource} from "../../models/resource.interface";
import {ActivatedRoute} from "@angular/router";
import {ResourceService} from "../../services/resource.service";
import {ResourceTypeService} from "../../services/resourceType.service";
import {IResourceType} from "../../models/resourceType.interface";
import {ResourceEditDialog} from "../resource-edit/resource-edit.component";
import {ResourceParamsDialog} from "../res-params/res-params.component";
import {ConfirmDialog} from "../../confirm-dialog/confirm-dialog.component";

@Component({
  selector: 'app-resources-list',
  templateUrl: './resources-list.component.html',
})
export class ResourcesListComponent implements OnInit {
  resources$: IResource[] = [];
  resType: IResourceType = null;

  displayedColumns: string[] = ['name', 'price', 'actions'];
  dataSource = new MatTableDataSource(this.resources$);

  constructor(private _resourceService: ResourceService, private _resourceTypeService: ResourceTypeService,
              public dialog: MatDialog, private _snackBar: MatSnackBar, private _router: ActivatedRoute) {
  }

  ngOnInit() {
    this._router.params.subscribe(
      params => {
        let id = +params['id'];
        this._resourceService.getResourcesByType(id).subscribe(httpResult => {
          this.resources$ = httpResult.resources;
          this.updateDataSource();
        });
        this._resourceTypeService.getResourceType(id).subscribe(httpResult => {
          if (httpResult.status === "success") {
            this.resType = httpResult.data;
          }
        });
      });
  }

  updateDataSource() {
    this.dataSource = new MatTableDataSource(this.resources$);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  openEditDialog(element: IResource): void {
    const dialogRef = this.dialog.open(ResourceEditDialog, {
      width: '350px',
      data: {
        isNew: !element,
        title: element ? `Ресурс: ${element.name}` : 'Новый ресурс',
        name: element ? element.name : '',
        price: element ? element.price : 0,
        id: element ? element.id : -1
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result.isNew) {
        this._resourceService.addResource(this.resType.id, result).subscribe(httpResult => {
          if (httpResult.status === "success") {
            this.resources$.push(httpResult.data);
            this.updateDataSource();
          } else {
            this.openSnackBar(httpResult.message)
          }
        });
      } else {
        this._resourceService.updateResource(result.id, result).subscribe(httpResult => {
          if (httpResult.status === "success") {
            this.resources$ = this.resources$.map(x => x.id === result.id ? httpResult.data : x);
            this.updateDataSource();
          } else {
            this.openSnackBar(httpResult.message)
          }
        });
      }
    });
  }

  openDeleteDialog(elementId: number): void {
    const dialogRef = this.dialog.open(ConfirmDialog, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result)
        return;

      this._resourceService.deleteResource(elementId).subscribe(httpResult => {
        if (httpResult.status === "success") {
          this.resources$ = this.resources$.filter(x => x.id !== elementId);
          this.updateDataSource();
        } else {
          this.openSnackBar(httpResult.message)
        }
      });

    });
  }

  openParamsDialog(element: IResource): void {
    this.dialog.open(ResourceParamsDialog, {
      data: element,
      width: '700px',
    });
  }

  openSnackBar(text: string) {
    this._snackBar.openFromComponent(SnackAlertComponent, {
      data: text,
      duration: 4000,
    });
  }
}
