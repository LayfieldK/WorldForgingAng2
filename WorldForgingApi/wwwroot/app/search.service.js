System.register(["@angular/core","@angular/http","rxjs/add/operator/map"],function(exports_1,context_1){"use strict";var core_1,http_1,SearchService,__decorate=(context_1&&context_1.id,this&&this.__decorate||function(decorators,target,key,desc){var d,c=arguments.length,r=c<3?target:null===desc?desc=Object.getOwnPropertyDescriptor(target,key):desc;if("object"==typeof Reflect&&"function"==typeof Reflect.decorate)r=Reflect.decorate(decorators,target,key,desc);else for(var i=decorators.length-1;i>=0;i--)(d=decorators[i])&&(r=(c<3?d(r):c>3?d(target,key,r):d(target,key))||r);return c>3&&r&&Object.defineProperty(target,key,r),r}),__metadata=this&&this.__metadata||function(k,v){if("object"==typeof Reflect&&"function"==typeof Reflect.metadata)return Reflect.metadata(k,v)};return{setters:[function(core_1_1){core_1=core_1_1},function(http_1_1){http_1=http_1_1},function(_1){}],execute:function(){SearchService=function(){function SearchService(http){this.http=http}return SearchService.prototype.search=function(term){return this.http.get("app/articles/?name="+term).map(function(response){return response.json().data})},SearchService=__decorate([core_1.Injectable(),__metadata("design:paramtypes",[http_1.Http])],SearchService)}(),exports_1("SearchService",SearchService)}}});
//# sourceMappingURL=search.service.js.map
