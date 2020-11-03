import {Component, Input} from '@angular/core';
import {IResource} from "../../models/resource.interface";

@Component({
  selector: 'app-resource-info',
  templateUrl: './resource-info.component.html',
  styleUrls: ['./resource-info.component.css'],
})
export class ResourceInfoComponent {
  @Input() resource: IResource;
}
