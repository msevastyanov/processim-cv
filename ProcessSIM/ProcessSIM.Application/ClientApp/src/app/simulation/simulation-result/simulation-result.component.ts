import {Component, Input} from '@angular/core';
import {ISimulationResult} from "../../models/simulationResult.interface";

@Component({
  selector: 'app-simulation-result',
  templateUrl: './simulation-result.component.html',
  styleUrls: ['./simulation-result.component.css'],
})
export class SimulationResultComponent {
  @Input() result: ISimulationResult;

  timeConvert(minutesData) {
    if (minutesData < 60)
      return minutesData;

    const minutes = minutesData % 60;
    const hours = (minutesData - minutes) / 60;

    return `${hours} ч ${minutes} мин`;
  }
}
