import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';

import {CommonModule} from '@angular/common';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatDialogModule} from '@angular/material/dialog';
import {FormsModule} from "@angular/forms";
import {MatSnackBarModule} from '@angular/material/snack-bar';

import {ResourcesComponent} from './resources.component';
import {ResCategoriesComponent} from './res-categories/res-categories.component';
import {ResourceCategoryEditDialog} from './res-category-edit/res-category-edit.component';
import {ResTypesComponent} from "./res-types/res-types.component";
import {ResourceTypeEditDialog} from "./res-type-edit/res-type-edit.component";
import {ResourceTypeParamsDialog} from "./res-type-params/res-type-params.component";
import {ResourcesListComponent} from "./resources-list/resources-list.component";
import {ResourceEditDialog} from "./resource-edit/resource-edit.component";
import {ResourceParamsDialog} from "./res-params/res-params.component";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: ResourcesComponent,
        children: [
          {
            path: '',
            component: ResCategoriesComponent,
          },
          {
            path: 'by-type/:id',
            component: ResourcesListComponent,
          }]
      },
    ]),
    MatCardModule,
    MatTableModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
    MatDialogModule,
    MatSnackBarModule,
    FormsModule
  ],
  entryComponents: [ResourceCategoryEditDialog, ResourceTypeEditDialog, ResourceTypeParamsDialog, ResourceEditDialog, ResourceParamsDialog],
  declarations: [
    ResourcesComponent,
    ResCategoriesComponent,
    ResourceCategoryEditDialog,
    ResTypesComponent,
    ResourceTypeEditDialog,
    ResourceTypeParamsDialog,
    ResourcesListComponent,
    ResourceEditDialog,
    ResourceParamsDialog,
  ],
  providers: [],
})
export class ResourcesModule {
}
