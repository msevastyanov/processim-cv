import {Component, EventEmitter, Input, Output} from '@angular/core';
import * as go from "gojs";

@Component({
  selector: 'app-selected-node',
  templateUrl: './selected-node.component.html',
  styleUrls: ['./selected-node.component.css'],
})
export class SelectedNodeComponent {
  @Input() selectedNode: go.Node;
  @Input() complexity: number;

  @Output()
  public updateProcedureParameters: EventEmitter<any> = new EventEmitter<any>();

  public handleProcParamsChange(newData) {
    this.updateProcedureParameters.emit(newData);
  }
}
