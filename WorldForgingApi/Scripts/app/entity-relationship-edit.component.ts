import {Component, Input} from "@angular/core";
import { FormGroup } from '@angular/forms';
import { EntityRelationship } from "./entity-relationship"



@Component({
    selector: "entity-relationship-edit",
    template: `
          <div [formGroup]="entityRelationshipForm"  id="entity-relationship-edit-component">
            <div  class="relationship-item" >
              <input type="text" class="form-control" formControlName="Entity1Name">
              {{entityRelationship.Entity1Name}} {{entityRelationship.Description}} {{entityRelationship.Entity2Name}}
                <select></select>
                <select></select>
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

    constructor() {}
        




}
