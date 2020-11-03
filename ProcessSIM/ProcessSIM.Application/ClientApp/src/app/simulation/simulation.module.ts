import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';

import {CommonModule} from '@angular/common';
import {GojsAngularModule} from 'gojs-angular';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatInputModule} from '@angular/material/input';
import {MatRadioModule} from '@angular/material/radio';
import {FormsModule} from "@angular/forms";

import {SimulationComponent} from './simulation.component';
import {SimulationControlComponent} from "./simulation-control/simulation-control.component";
import {ProceduresPaletteComponent} from "./procedures-palette/procedures-palette.component";
import {ResourcesPaletteComponent} from "./resources-palette/resources-palette.component";
import {OtherPaletteComponent} from "./other-palette/other-palette.component";
import {SimulationDiagramComponent} from "./simulation-diagram/simulation-diagram.component";
import {SelectedNodeComponent} from "./selected-node/selected-node.component";
import {ResourceInfoComponent} from "./resource-info/resource-info.component";
import {ProcedureInfoComponent} from "./procedure-info/procedure-info.component";
import {SimulationResultComponent} from "./simulation-result/simulation-result.component";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {SimDataDialog} from "./sim-data/sim-data.component";
import {MatDialogModule} from "@angular/material/dialog";
import {InputComplexityDialog} from "./input-complexity/input-complexity.component";

@NgModule({
  imports: [
    CommonModule,
    GojsAngularModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
    MatInputModule,
    MatRadioModule,
    MatSnackBarModule,
    MatDialogModule,
    RouterModule.forChild([
      {
        path: '',
        component: SimulationComponent,
      },
    ]),
    FormsModule
  ],
  entryComponents: [SimDataDialog, InputComplexityDialog],
  declarations: [
    SimulationComponent,
    SimulationControlComponent,
    ProceduresPaletteComponent,
    ResourcesPaletteComponent,
    OtherPaletteComponent,
    SimulationDiagramComponent,
    SelectedNodeComponent,
    ResourceInfoComponent,
    ProcedureInfoComponent,
    SimulationResultComponent,
    SimDataDialog,
    InputComplexityDialog,
  ],
  providers: [],
})
export class SimulationModule {
}
