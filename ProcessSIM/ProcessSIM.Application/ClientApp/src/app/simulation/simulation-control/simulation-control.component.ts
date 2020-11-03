import {Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-sim-control',
  templateUrl: './simulation-control.component.html',
})
export class SimulationControlComponent {
  @Output()
  public startSimulation: EventEmitter<any> = new EventEmitter<any>();

  @Output()
  public clearSimulation: EventEmitter<any> = new EventEmitter<any>();

  @Output()
  public simConfig: EventEmitter<any> = new EventEmitter<any>();

  @Output()
  public simComplexity: EventEmitter<any> = new EventEmitter<any>();

  start() {
    this.startSimulation.emit();
  }

  clear() {
    this.clearSimulation.emit();
  }

  config() {
    this.simConfig.emit();
  }

  complexity() {
    this.simComplexity.emit();
  }
}
