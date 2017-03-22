System.register(["@angular/core"],function(exports_1,context_1){"use strict";var core_1,RelationshipListComponent,__decorate=(context_1&&context_1.id,this&&this.__decorate||function(decorators,target,key,desc){var d,c=arguments.length,r=c<3?target:null===desc?desc=Object.getOwnPropertyDescriptor(target,key):desc;if("object"==typeof Reflect&&"function"==typeof Reflect.decorate)r=Reflect.decorate(decorators,target,key,desc);else for(var i=decorators.length-1;i>=0;i--)(d=decorators[i])&&(r=(c<3?d(r):c>3?d(target,key,r):d(target,key))||r);return c>3&&r&&Object.defineProperty(target,key,r),r}),__metadata=this&&this.__metadata||function(k,v){if("object"==typeof Reflect&&"function"==typeof Reflect.metadata)return Reflect.metadata(k,v)};return{setters:[function(core_1_1){core_1=core_1_1}],execute:function(){RelationshipListComponent=function(){function RelationshipListComponent(){}return RelationshipListComponent.prototype.ngOnInit=function(){},RelationshipListComponent.prototype.onInsert=function(article){},RelationshipListComponent.prototype.onUpdate=function(article){},RelationshipListComponent.prototype.onDelete=function(article){},RelationshipListComponent=__decorate([core_1.Component({selector:"relationships",template:'\n        <div id="relationship-list-component">\n          <h4>Relationships</h4>\n          <div id="relationship-list">\n            <div *ngFor="let relationship of relationships" class="relationship-item" >\n              {{relationship.Description}}\n            </div>\n          </div>\n        </div>\n    ',styles:[]}),__metadata("design:paramtypes",[])],RelationshipListComponent)}(),exports_1("RelationshipListComponent",RelationshipListComponent)}}});
//# sourceMappingURL=relationship-list.component.js.map