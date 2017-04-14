System.register(["@angular/core", "@angular/forms", "./entity-relationship"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, forms_1, entity_relationship_1, EntityRelationshipEditComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (entity_relationship_1_1) {
                entity_relationship_1 = entity_relationship_1_1;
            }
        ],
        execute: function () {
            EntityRelationshipEditComponent = (function () {
                function EntityRelationshipEditComponent() {
                }
                return EntityRelationshipEditComponent;
            }());
            __decorate([
                core_1.Input('group'),
                __metadata("design:type", forms_1.FormGroup)
            ], EntityRelationshipEditComponent.prototype, "entityRelationshipForm", void 0);
            __decorate([
                core_1.Input('entityRelationship'),
                __metadata("design:type", entity_relationship_1.EntityRelationship)
            ], EntityRelationshipEditComponent.prototype, "entityRelationship", void 0);
            __decorate([
                core_1.Input('relationships'),
                __metadata("design:type", Array)
            ], EntityRelationshipEditComponent.prototype, "relationships", void 0);
            EntityRelationshipEditComponent = __decorate([
                core_1.Component({
                    selector: "entity-relationship-edit",
                    template: "\n          <div [formGroup]=\"entityRelationshipForm\"  id=\"entity-relationship-edit-component\">\n            <div  class=\"relationship-item\" >\n              <input type=\"text\" class=\"form-control\" formControlName=\"Entity1Name\">\n              <input type=\"text\" class=\"form-control\" formControlName=\"Description\">\n              <input type=\"text\" class=\"form-control\" formControlName=\"RelationshipDescription\">\n              <input type=\"text\" class=\"form-control\" formControlName=\"RelationshipId\">\n              {{entityRelationship.Entity1Name}} {{entityRelationship.Description}} {{entityRelationship.Entity2Name}}\n              <select class=\"form-control\" formControlName=\"Relationship\">\n                    <option *ngFor=\"let relationship of relationships\" [value]=\"relationship.Id\">{{relationship.Description}}</option>\n              </select>\n            </div>\n          </div>\n    ",
                    styles: []
                }),
                __metadata("design:paramtypes", [])
            ], EntityRelationshipEditComponent);
            exports_1("EntityRelationshipEditComponent", EntityRelationshipEditComponent);
        }
    };
});
