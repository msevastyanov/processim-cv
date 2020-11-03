import {ChangeDetectorRef, Component, Input, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import * as go from 'gojs';
import {DataSyncService, PaletteComponent} from 'gojs-angular';

@Component({
  selector: 'app-resources-palette',
  templateUrl: './resources-palette.component.html',
  styleUrls: ['./resources-palette.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ResourcesPaletteComponent implements OnInit {
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

    palette.nodeTemplateMap.add("Resource",
      $(go.Node, 'Auto',
        $(go.Shape, 'RoundedRectangle',
          {
            stroke: null,
            fill: "#009688",
            desiredSize: new go.Size(280, 40),
          },
          // new go.Binding('fill', 'color')
        ),
        $(go.TextBlock, {margin: 8, font: "11px sans-serif", stroke: "#fff"},
          new go.Binding('text', 'name'))
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
