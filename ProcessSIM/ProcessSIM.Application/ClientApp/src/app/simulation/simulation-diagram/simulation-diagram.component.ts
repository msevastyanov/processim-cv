import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
  ViewEncapsulation
} from '@angular/core';
import * as go from 'gojs';
import {DataSyncService, DiagramComponent} from 'gojs-angular';

@Component({
  selector: 'app-simulation-diagram',
  templateUrl: './simulation-diagram.component.html',
  styleUrls: ['./simulation-diagram.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SimulationDiagramComponent implements OnInit {
  @ViewChild('myDiagram', {static: true}) public myDiagramComponent: DiagramComponent;

  @Input() diagramNodeData: Array<go.ObjectData>;
  @Input() diagramLinkData: Array<go.ObjectData>;

  @Output()
  public onChangeSelectedNode: EventEmitter<any> = new EventEmitter<any>();

  @Output()
  public onChangeDiagramData: EventEmitter<any> = new EventEmitter<any>();

  constructor(private cdr: ChangeDetectorRef) {

  }

  ngOnInit() {

  }

  // initialize diagram / templates
  public initDiagram(): go.Diagram {

    const $ = go.GraphObject.make;
    const dia = $(go.Diagram, {
      'undoManager.isEnabled': true,
      model: $(go.GraphLinksModel,
        {
          linkToPortIdProperty: 'toPort',
          linkFromPortIdProperty: 'fromPort',
          linkKeyProperty: 'key' // IMPORTANT! must be defined for merges and data sync when using GraphLinksModel
        }
      )
    });

    function makePort(name, align, spot, output, input) {
      const horizontal = align.equals(go.Spot.Top) || align.equals(go.Spot.Bottom);
      // the port is basically just a transparent rectangle that stretches along the side of the node,
      // and becomes colored when the mouse passes over it
      return $(go.Shape,
        {
          fill: "transparent",  // changed to a color in the mouseEnter event handler
          strokeWidth: 0,  // no stroke
          width: horizontal ? NaN : 7,  // if not stretching horizontally, just 8 wide
          height: !horizontal ? 40 : 7,  // if not stretching vertically, just 8 tall
          alignment: align,  // align the port on the main Shape
          stretch: (horizontal ? go.GraphObject.Horizontal : go.GraphObject.Vertical),
          portId: name,  // declare this object to be a "port"
          fromSpot: spot,  // declare where links may connect at this port
          fromLinkable: output,  // declare whether the user may draw links from here
          toSpot: spot,  // declare where links may connect at this port
          toLinkable: input,  // declare whether the user may draw links to here
          cursor: "pointer",  // show a different cursor to indicate potential link point
          mouseEnter: function (e, port) {  // the PORT argument will be this Shape
            if (!e.diagram.isReadOnly) port.fill = "rgba(255,76,23,0.5)";
          },
          mouseLeave: function (e, port) {
            port.fill = "transparent";
          }
        });
    };

    dia.nodeTemplateMap.add("Procedure",
      $(go.Node, 'Auto',
        $(go.Panel, 'Auto',
          $(go.Shape, 'RoundedRectangle',
            {
              stroke: null,
              fill: "#1976D2",
              desiredSize: new go.Size(180, 60),
            },
          ),
          $(go.TextBlock, {margin: 2, stroke: "#fff", textAlign: "center"},
            new go.Binding('text', 'alias'))
        ),
        // Ports
        makePort('t', go.Spot.Top, go.Spot.TopSide, true, true),
        makePort('l', go.Spot.Left, go.Spot.LeftSide, true, true),
        makePort('r', go.Spot.Right, go.Spot.RightSide, true, true),
        makePort('b', go.Spot.Bottom, go.Spot.BottomSide, true, true)
      ));

    dia.nodeTemplateMap.add("Resource",
      $(go.Node, 'Auto',
        $(go.Panel, 'Auto',
          $(go.Shape, 'RoundedRectangle',
            {
              stroke: null,
              fill: "#009688",
              desiredSize: new go.Size(140, 40),
            },
            // new go.Binding('fill', 'color')
          ),
          $(go.TextBlock, {margin: 2, stroke: "#fff", textAlign: "center"},
            new go.Binding('text', 'name'))
        ),
        // Ports
        makePort('t', go.Spot.Top, go.Spot.TopSide, true, false),
        makePort('l', go.Spot.Left, go.Spot.LeftSide, true, false),
        makePort('r', go.Spot.Right, go.Spot.RightSide, true, false),
        makePort('b', go.Spot.Bottom, go.Spot.BottomSide, true, false)
      ));

    dia.nodeTemplateMap.add("Start",
      $(go.Node, "Auto",
        $(go.Panel, 'Auto',
          $(go.Shape, "Circle",
            {desiredSize: new go.Size(65, 65), fill: "#FFA726", stroke: "#FFA726"}),
          $(go.TextBlock, "",
            new go.Binding("text"))
        ),
        makePort('r', go.Spot.Right, go.Spot.RightSide, true, false),
        makePort('l', go.Spot.Left, go.Spot.LeftSide, true, false),
      ));

    dia.nodeTemplateMap.add("End",
      $(go.Node, "Auto",
        $(go.Panel, 'Auto',
          $(go.Shape, "Circle",
            {desiredSize: new go.Size(65, 65), fill: "#F57C00", stroke: "#F57C00"}),
          $(go.TextBlock, "",
            new go.Binding("text"))
        ),
        makePort('l', go.Spot.Left, go.Spot.LeftSide, false, true),
        makePort('r', go.Spot.Right, go.Spot.RightSide, false, true),
      ));

    return dia;
  }

  public diagramDivClassName: string = 'diagram';
  public diagramModelData = {prop: 'value'};

  // When the diagram model changes, update app data to reflect those changes
  public diagramModelChange = function (changes: go.IncrementalData) {
    this.diagramNodeData = DataSyncService.syncNodeData(changes, this.diagramNodeData);
    this.diagramLinkData = DataSyncService.syncLinkData(changes, this.diagramLinkData);
    this.diagramModelData = DataSyncService.syncModelData(changes, this.diagramModelData);
    this.onChangeDiagramData.emit({nodeData: this.diagramNodeData, linkData: this.diagramLinkData});
  };

  public ngAfterViewInit() {
    const that = this;

    this.cdr.detectChanges(); // IMPORTANT: without this, Angular will throw ExpressionChangedAfterItHasBeenCheckedError (dev mode only)

    // listener for inspector
    this.myDiagramComponent.diagram.addDiagramListener('ChangedSelection', function (e) {
      if (e.diagram.selection.count === 0) {
        that.onChangeSelectedNode.emit(null);
      }
      const node = e.diagram.selection.first();
      if (node instanceof go.Node) {
        that.onChangeSelectedNode.emit(node);
      } else {
        that.onChangeSelectedNode.emit(null);
      }
    });
  } // end ngAfterViewInit

}
