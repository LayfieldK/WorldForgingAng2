System.register(["@angular/core"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1;
    var RelationshipListComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            RelationshipListComponent = (function () {
                function RelationshipListComponent() {
                }
                RelationshipListComponent.prototype.ngOnInit = function () {
                };
                RelationshipListComponent.prototype.onInsert = function (article) {
                };
                RelationshipListComponent.prototype.onUpdate = function (article) {
                };
                RelationshipListComponent.prototype.onDelete = function (article) {
                };
                RelationshipListComponent = __decorate([
                    core_1.Component({
                        selector: "relationships",
                        template: "\n        <div id=\"relationship-list-component\">\n          <h4>Relationships</h4>\n          <div id=\"relationship-list\">\n            <div *ngFor=\"let relationship of relationships\" class=\"relationship-item\" >\n              {{relationship.Description}}\n            </div>\n          </div>\n        </div>\n    ",
                        styles: []
                    }), 
                    __metadata('design:paramtypes', [])
                ], RelationshipListComponent);
                return RelationshipListComponent;
            }());
            exports_1("RelationshipListComponent", RelationshipListComponent);
        }
    }
});
