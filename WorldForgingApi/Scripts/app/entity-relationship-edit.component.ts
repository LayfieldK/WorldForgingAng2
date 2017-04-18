import { Component, Input, OnInit} from "@angular/core";
import { FormGroup } from '@angular/forms';
import { EntityRelationship } from "./entity-relationship"
import { Relationship } from "./relationship"
import { Entity } from "./entity"


@Component({
    selector: "entity-relationship-edit",
    template: `
          <div [formGroup]="entityRelationshipForm"  id="entity-relationship-edit-component">
            <div  class="relationship-item" >
              

              
              <select class="form-control" formControlName="Entity2Id">
                    <option *ngFor="let entity of entities" [value]="entity.Id">{{entity.Name}}</option>
              </select>
              
              <select class="form-control" formControlName="Relationship">
                    <option *ngFor="let relationship of relationships" [value]="relationship.Id">{{relationship.Description}}</option>
              </select>
            </div>
          </div>
    `,
    styles: []
})

export class EntityRelationshipEditComponent {

    @Input('group')
    public entityRelationshipForm: FormGroup;

    @Input('entityRelationship')
    public entityRelationship: EntityRelationship;

    @Input('relationships')
    public relationships: Relationship[];

    @Input('entities')
    public entities: Entity[];

    constructor() {
        //this.entityRelationshipForm.patchValue({
        //    Relationship: this.entityRelationship.RelationshipId
        //});
    }

    ngOnInit() {
        //console.log(this.entityRelationship);
        //console.log(this.entityRelationshipForm);
        //console.log(this.relationships);
        this.entityRelationshipForm.patchValue({
            Relationship: this.entityRelationship.RelationshipId
        });
        this.entityRelationshipForm.patchValue({
            Entity2Id: this.entityRelationship.Entity2Id
        });
    }
        




}
