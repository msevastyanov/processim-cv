import {Component, Inject} from "@angular/core";
import {MAT_SNACK_BAR_DATA} from "@angular/material/snack-bar";

@Component({
  selector: 'snack-alert',
  templateUrl: 'snack-alert.component.html',
})
export class SnackAlertComponent {
  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: any) { }
}
