import {ChangeDetectorRef, Component, Input, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import * as go from 'gojs';
import {DataSyncService, PaletteComponent} from 'gojs-angular';

@Component({
  selector: 'app-other-palette',
  templateUrl: './other-palette.component.html',
  styleUrls: ['./other-palette.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class OtherPaletteComponent implements OnInit {
  @ViewChild('myPalette', {static: true}) public myPaletteComponent: PaletteComponent;

  @Input() paletteNodeData: Array<go.ObjectData>;
  @Input() paletteLinkData: Array<go.ObjectData>;

  constructor(private cdr: ChangeDetectorRef) {

  }

  ngOnInit() {

  }

  public initPalette(): go.Palette {
    const $ = go.GraphObject.make;
    const palette = $(go.Palette);

    palette.model = $(go.GraphLinksModel,
      {
        linkKeyProperty: 'key'  // IMPORTANT! must be defined for merges and data sync when using GraphLinksModel
      });

    palette.nodeTemplateMap.add("Start",
      $(go.Node, "Auto",
        $(go.Shape, "Circle",
          {desiredSize: new go.Size(50, 50), fill: "#FFA726", stroke: "#FFA726"}),
        $(go.TextBlock, "Начало",
          new go.Binding("text"))
      ));

    palette.nodeTemplateMap.add("End",
      $(go.Node, "Auto",
        $(go.Shape, "Circle",
          {desiredSize: new go.Size(50, 50), fill: "#F57C00", stroke: "#F57C00"}),
        $(go.TextBlock, "Конец",
          new go.Binding("text"))
      ));

    return palette;
  }

  public paletteModelData = {prop: 'val'};
  public paletteDivClassName = 'palette';
  public paletteModelChange = function (changes: go.IncrementalData) {
    this.paletteNodeData = DataSyncService.syncNodeData(changes, this.paletteNodeData);
    this.paletteLinkData = DataSyncService.syncLinkData(changes, this.paletteLinkData);
    this.paletteModelData = DataSyncService.syncModelData(changes, this.paletteModelData);
  };
}
