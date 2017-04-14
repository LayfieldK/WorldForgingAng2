import { Component, Input, OnInit} from "@angular/core";
import { FormGroup } from '@angular/forms';
import { EntityRelationship } from "./entity-relationship"
import { Relationship } from "./relationship"


@Component({
    selector: "entity-relationship-edit",
    template: `
          <div [formGroup]="entityRelationshipForm"  id="entity-relationship-edit-component">
            <div  class="relationship-item" >
              <input type="text" class="form-control" formControlName="Entity1Name">
              <input type="text" class="form-control" formControlName="Description">
              <input type="text" class="form-control" formControlName="RelationshipDescription">
              <input type="text" class="form-control" formControlName="RelationshipId">
              <input type="text" class="form-control" formControlName="Entity2Name">
              
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

    constructor() {
        //this.entityRelationshipForm.patchValue({
        //    Relationship: this.entityRelationship.RelationshipId
        //});
    }

    ngOnInit() {
        console.log(this.entityRelationship);
        console.log(this.entityRelationshipForm);
        console.log(this.relationships);
        this.entityRelationshipForm.patchValue({
            Relationship: this.entityRelationship.RelationshipId
        });
    }
        




}
