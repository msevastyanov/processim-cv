import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import * as go from 'gojs';
import {ProcedureService} from "../services/procedure.service";
import {IProcedure} from "../models/procedure.interface";
import {IResource} from "../models/resource.interface";
import {ResourceService} from "../services/resource.service";
import {SimulationService} from "../services/simulation.service";
import {SnackAlertComponent} from "../snack-alert/snack-alert.component";
import {MatSnackBar} from "@angular/material/snack-bar";
import {ISimulationResult} from "../models/simulationResult.interface";
import {SimDataDialog} from "./sim-data/sim-data.component";
import {MatDialog} from "@angular/material/dialog";
import {InputComplexityDialog} from "./input-complexity/input-complexity.component";
import {IComplexity} from "../models/complexity.interface";

@Component({
  selector: 'app-simulation',
  templateUrl: './simulation.component.html',
  styleUrls: ['./simulation.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SimulationComponent implements OnInit {
  procedures$: IProcedure[] = [];
  resources$: IResource[] = [];
  simulationResult: ISimulationResult;
  step: number = 2;
  complexity: number = 1;
  simulationName: string = "Новое моделирование";

  complexityValues: IComplexity = {
    originalDetailsCountValue: 0.3,
    isStandardDetailsValue: 0,
    isAssemblyUnitsSurfValue: 0,
    isAssemblyUnitsConnValue: 0,
    surfaceFormValue: 0.5,
    isStructuralElementsValue: 1,
    workWithPartsValue: 1,
    isRestrictDetailsValue: 1
  };

  constructor(private _procedureService: ProcedureService, private _resourceService: ResourceService,
              private _simulationService: SimulationService, private _snackBar: MatSnackBar, public dialog: MatDialog) {

  }

  ngOnInit() {
    this.calcComplexity();
    this.updateComplexity();
    this._procedureService.getProcedures().subscribe(httpResult => {
      this.procedures$ = httpResult.procedures;
      this.procPaletteNodeData = this.procedures$.map((procedure: IProcedure) => {
        return {
          ...procedure,
          key: procedure.name,
          category: 'Procedure',
          parameters: procedure.parameters.map(p => {
            return {
              ...p,
              value: p.name === "design_object_complexity" ? this.complexity.toString() : ""
            }
          })
        }
      });
    });

    this._resourceService.getResources().subscribe(httpResult => {
      this.resources$ = httpResult.resources;
      this.resPaletteNodeData = this.resources$.map((resource: IResource) => {
        return {
          ...resource,
          key: resource.name,
          category: 'Resource'
        }
      });
    });
  }

  public procPaletteNodeData: Array<go.ObjectData> = [];
  public procPaletteLinkData: Array<go.ObjectData> = [
    // {from: 'PaletteNode1', to: 'PaletteNode2'}
  ];

  public resPaletteNodeData: Array<go.ObjectData> = [];
  public resPaletteLinkData: Array<go.ObjectData> = [];

  public otherPaletteNodeData: Array<go.ObjectData> = [
    {
      key: 'Start',
      category: 'Start'
    },
    {
      key: 'End',
      category: 'End'
    }
  ];
  public otherPaletteLinkData: Array<go.ObjectData> = [];

  public diagramNodeData: Array<go.ObjectData> = [];
  public diagramLinkData: Array<go.ObjectData> = [];

  //currently selected node; for inspector
  public selectedNode: go.Node | null = null;

  public setSelectedNode(newSelectedNode) {
    this.selectedNode = newSelectedNode;
  }

  public updateProcedureParameters(newData) {
    const key = newData.key;
    let index = null;
    for (let i = 0; i < this.diagramNodeData.length; i++) {
      const entry = this.diagramNodeData[i];
      if (entry.key && entry.key === key) {
        index = i;
      }
    }

    if (index >= 0) {
      this.diagramNodeData[index] = {
        ...this.diagramNodeData[index],
        parameters: [...newData.parameters]
      };
    }
  }

  updateDiagramData(data) {
    this.diagramNodeData = data.nodeData;
    this.diagramLinkData = data.linkData;
  }

  checkValidation(): boolean {
    const isStartCorrect = this.diagramLinkData.find(x => x.from === "Start");
    const isFinishCorrect = this.diagramLinkData.find(x => x.to === "End");

    return !(!isStartCorrect || !isFinishCorrect);
  }

  startSimulation() {
    if (!this.checkValidation()) {
      this.openSnackBar("У процесса должны быть начало и конец");
      return;
    }

    const procedureNodes = this.diagramNodeData.filter(x => x.category === "Procedure");
    const resourceNodes = this.diagramNodeData.filter(x => x.category === "Resource");

    const simProcedures = procedureNodes.map(x => {
      return {
        procedureKey: x.key,
        procedureName: x.name,
        procedureParameters: x.parameters.map(p => {
          return {
            procedureParameterName: p.name,
            procedureParameterValue: p.value
          }
        }),
      }
    });

    const simResources = resourceNodes.map(x => {
      return {
        resourceKey: x.key,
        resourceId: x.id
      }
    });

    const procLinks = this.diagramLinkData.filter(l => procedureNodes.map(rd => rd.key).includes(l.from) && procedureNodes.map(rd => rd.key).includes(l.to)).map(l => {
      return {
        procedureFromKey: l.from,
        procedureToKey: l.to
      }
    });

    const procResLinks = this.diagramLinkData.filter(l => resourceNodes.map(rd => rd.key).includes(l.from)).map(l => {
      return {
        resourceKey: l.from,
        procedureKey: l.to
      }
    });

    const startProcKey = this.diagramLinkData.find(l => l.from === "Start").to;

    const startSimulationModel = {
      procedures: simProcedures,
      resources: simResources,
      procLinks,
      procResLinks,
      startProcKey,
      step: this.step,
      complexity: +this.complexity,
      simulationName: this.simulationName
    };

    this._simulationService.startSimulation(startSimulationModel).subscribe(httpResult => {
      if (httpResult.status === "success") {
        this.simulationResult = httpResult.data;
      }
    });
  }

  clearSimulation() {
    this.diagramNodeData = [];
    this.diagramLinkData = [];
  }

  simConfig() {
    const dialogRef = this.dialog.open(SimDataDialog, {
      width: '350px',
      data: {
        step: this.step,
        simulationName: this.simulationName,
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result)
        return;

      this.step = result.step;
      this.simulationName = result.simulationName;
      this.updateComplexity();
    });
  }

  simComplexity() {
    const dialogRef = this.dialog.open(InputComplexityDialog, {
      width: '900px',
      data: this.complexityValues
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result)
        return;

      this.complexityValues = result;
      this.calcComplexity();
      this.updateComplexity();
    });
  }

  calcComplexity() {
    const c1 = (this.complexityValues.originalDetailsCountValue + this.complexityValues.isStandardDetailsValue) / 2;
    const c2 = (this.complexityValues.isAssemblyUnitsSurfValue + this.complexityValues.isAssemblyUnitsConnValue) / 2;
    const c3 = (this.complexityValues.surfaceFormValue + this.complexityValues.isStructuralElementsValue + this.complexityValues.workWithPartsValue + this.complexityValues.isRestrictDetailsValue) / 4;
    this.complexity = ((c1 + c2 + c3) / 3);
  }

  updateComplexity() {
    this.diagramNodeData = this.diagramNodeData.map(d => {
      return d.category === "Procedure" ? {
        ...d,
        parameters: d.parameters.map(p => {
          return {
            ...p,
            value: p.name === "design_object_complexity" ? this.complexity.toString() : p.value
          }
        })
      } : d
    })
  }

  openSnackBar(text: string) {
    this._snackBar.openFromComponent(SnackAlertComponent, {
      data: text,
      duration: 4000,
    });
  }
}
