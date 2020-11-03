import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {IProcedure} from "../../models/procedure.interface";
import {IProcedureParameter} from "../../models/procedureParameter.interface";
import * as go from "gojs";
import {IProcedureGo} from "../../models/procedureGo.interface";

@Component({
  selector: 'app-procedure-info',
  templateUrl: './procedure-info.component.html',
  styleUrls: ['./procedure-info.component.css'],
})
export class ProcedureInfoComponent implements OnChanges {
  @Input() procedure: IProcedureGo;

  @Output()
  public onFormChange: EventEmitter<any> = new EventEmitter<any>();

  isEditMode: boolean = false;

  parameters: IProcedureParameter[] = [];

  // ngOnInit(): void {
  //   this.parameters = this.procedure.parameters.map(param => {
  //     return {
  //       name: param.name,
  //       alias: param.alias,
  //       value: param.value,
  //     }
  //   })
  // }

  ngOnChanges(changes: SimpleChanges) {
    this.parameters = this.procedure.parameters.map(param => {
      return {
        name: param.name,
        alias: param.alias,
        value: param.value,
      }
    })
  }

  setIsEditMode() {
    this.isEditMode = true;
  }

  save() {
    this.isEditMode = false;
    this.onFormChange.emit({
      key: this.procedure.key,
      parameters: this.parameters
    });
  }

  filterParameters() {
    return this.parameters.filter(x => x.name !== "design_object_complexity");
  }
}
