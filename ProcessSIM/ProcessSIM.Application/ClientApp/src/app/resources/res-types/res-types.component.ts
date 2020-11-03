import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {MatTableDataSource} from '@angular/material/table';
import {IResourceCategory} from "../../models/resourceCategory.interface";
import {ResourceCategoryEditDialog} from "../res-category-edit/res-category-edit.component";
import {MatSnackBar} from "@angular/material/snack-bar";
import {SnackAlertComponent} from "../../snack-alert/snack-alert.component";
import {IResourceType} from "../../models/resourceType.interface";
import {ResourceTypeService} from "../../services/resourceType.service";
import {ResourceTypeParamsDialog} from "../res-type-params/res-type-params.component";
import {ConfirmDialog} from "../../confirm-dialog/confirm-dialog.component";

@Component({
  selector: 'app-res-types',
  templateUrl: './res-types.component.html',
})
export class ResTypesComponent implements OnChanges {
  @Input() resourceCategory: IResourceCategory;

  @Output()
  public addResourceType: EventEmitter<any> = new EventEmitter<any>();

  @Output()
  public updateResourceType: EventEmitter<any> = new EventEmitter<any>();

  @Output()
  public deleteResourceType: EventEmitter<any> = new EventEmitter<any>();

  displayedColumns: string[] = ['name', 'resources','actions'];
  dataSource = new MatTableDataSource(this.resourceCategory && this.resourceCategory.resourceTypes);

  constructor(private _resourceTypeService: ResourceTypeService, public dialog: MatDialog, private _snackBar: MatSnackBar) {
  }

  ngOnChanges(changes: SimpleChanges) {
    this.updateDataSource();
  }

  updateDataSource() {
    this.dataSource = new MatTableDataSource(this.resourceCategory.resourceTypes);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  openEditDialog(element: IResourceType): void {
    const dialogRef = this.dialog.open(ResourceCategoryEditDialog, {
      width: '350px',
      data: {
        isNew: !element,
        title: element ? `Тип ресурса: ${element.name}` : 'Новый тип ресурса',
        name: element ? element.name : '',
        id: element ? element.id : -1
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result && result.isNew) {
        this._resourceTypeService.addResourceType(this.resourceCategory.id, result).subscribe(httpResult => {
          if (httpResult.status === "success") {
            this.addResourceType.emit(httpResult.data);
            // this.updateDataSource();
          } else {
            this.openSnackBar(httpResult.message)
          }
        });
      } else {
        this._resourceTypeService.updateResourceType(result.id, result).subscribe(httpResult => {
          if (httpResult.status === "success") {
            this.updateResourceType.emit(httpResult.data);
            // this.updateDataSource();
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

      this._resourceTypeService.deleteResourceType(elementId).subscribe(httpResult => {
        if (httpResult.status === "success") {
          this.deleteResourceType.emit(elementId);
          // this.updateDataSource();
        } else {
          this.openSnackBar(httpResult.message)
        }
      });

    });
  }

  openParamsDialog(element: IResourceType): void {
    this.dialog.open(ResourceTypeParamsDialog, {
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
