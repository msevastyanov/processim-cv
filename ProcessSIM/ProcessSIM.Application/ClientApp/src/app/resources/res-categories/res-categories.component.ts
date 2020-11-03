import {Component, OnInit} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {MatTableDataSource} from '@angular/material/table';
import {ResourceCategoryService} from "../../services/resourceCategory.service";
import {IResourceCategory} from "../../models/resourceCategory.interface";
import {ResourceCategoryEditDialog} from "../res-category-edit/res-category-edit.component";
import {MatSnackBar} from "@angular/material/snack-bar";
import {SnackAlertComponent} from "../../snack-alert/snack-alert.component";
import {IDirtyType} from "../../models/dirtyType.interface";
import {ConfirmDialog} from "../../confirm-dialog/confirm-dialog.component";

@Component({
  selector: 'app-res-categories',
  templateUrl: './res-categories.component.html',
  // styleUrls: ['./home.component.css']
})
export class ResCategoriesComponent implements OnInit {
  resourceCategories$: IResourceCategory[] = [];

  displayedColumns: string[] = ['name', 'actions'];
  dataSource = new MatTableDataSource(this.resourceCategories$);

  selectedCategory: IResourceCategory = null;

  constructor(private _resourceCategoryService: ResourceCategoryService, public dialog: MatDialog, private _snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this._resourceCategoryService.getResourceCategories().subscribe(httpResult => {
      this.resourceCategories$ = httpResult.resCategories;
      this.updateDataSource();
    });
  }

  updateDataSource() {
    this.dataSource = new MatTableDataSource(this.resourceCategories$);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  openEditDialog(element: IResourceCategory): void {
    const dialogRef = this.dialog.open(ResourceCategoryEditDialog, {
      width: '350px',
      data: {
        isNew: !element,
        title: element ? `Категория ресурса: ${element.name}` : 'Новая категория ресурса',
        name: element ? element.name : '',
        id: element ? element.id : -1
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result.isNew) {
        this._resourceCategoryService.addResourceCategory(result).subscribe(httpResult => {
          if (httpResult.status === "success") {
            this.resourceCategories$.push(httpResult.data);
            this.updateDataSource();
          } else {
            this.openSnackBar(httpResult.message)
          }
        });
      } else {
        this._resourceCategoryService.updateResourceCategory(result.id, result).subscribe(httpResult => {
          if (httpResult.status === "success") {
            this.resourceCategories$ = this.resourceCategories$.map(x => x.id === result.id ? httpResult.data : x);
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

      this._resourceCategoryService.deleteResourceCategory(elementId).subscribe(httpResult => {
        if (httpResult.status === "success") {
          this.resourceCategories$ = this.resourceCategories$.filter(x => x.id !== elementId);
          this.updateDataSource();
        } else {
          this.openSnackBar(httpResult.message)
        }
      });

    });
  }

  openSnackBar(text: string) {
    this._snackBar.openFromComponent(SnackAlertComponent, {
      data: text,
      duration: 4000,
    });
  }

  selectCategory(category: IResourceCategory) {
    this.selectedCategory = category;
  }

  addResourceType(data: IDirtyType) {
    this.selectedCategory = {
      ...this.selectedCategory,
      resourceTypes: [...this.selectedCategory.resourceTypes, data]
    }
  }

  updateResourceType(data: IDirtyType) {
    this.selectedCategory = {
      ...this.selectedCategory,
      resourceTypes: this.selectedCategory.resourceTypes.map(x => x.id === data.id ? data : x)
    }
  }

  deleteResourceType(typeId: number) {
    this.selectedCategory = {
      ...this.selectedCategory,
      resourceTypes: this.selectedCategory.resourceTypes.filter(x => x.id !== typeId)
    }
  }
}
