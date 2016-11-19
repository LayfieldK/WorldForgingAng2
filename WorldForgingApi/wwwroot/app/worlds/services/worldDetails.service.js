System.register(["@angular/core","@angular/http","rxjs/Observable"],function(exports_1,context_1){"use strict";var core_1,http_1,Observable_1,WorldDetailsService,__decorate=(context_1&&context_1.id,this&&this.__decorate||function(decorators,target,key,desc){var d,c=arguments.length,r=c<3?target:null===desc?desc=Object.getOwnPropertyDescriptor(target,key):desc;if("object"==typeof Reflect&&"function"==typeof Reflect.decorate)r=Reflect.decorate(decorators,target,key,desc);else for(var i=decorators.length-1;i>=0;i--)(d=decorators[i])&&(r=(c<3?d(r):c>3?d(target,key,r):d(target,key))||r);return c>3&&r&&Object.defineProperty(target,key,r),r}),__metadata=this&&this.__metadata||function(k,v){if("object"==typeof Reflect&&"function"==typeof Reflect.metadata)return Reflect.metadata(k,v)};return{setters:[function(core_1_1){core_1=core_1_1},function(http_1_1){http_1=http_1_1},function(Observable_1_1){Observable_1=Observable_1_1}],execute:function(){WorldDetailsService=function(){function WorldDetailsService(http){this.http=http,this.worldsUrl="http://localhost:51332/api/worldsapi/"}return WorldDetailsService.prototype.getWorldDetails=function(worldId){return this.http.get(this.worldsUrl+"/"+worldId).map(this.extractData).catch(this.handleError)},WorldDetailsService.prototype.extractData=function(res){var body=res.json();return body},WorldDetailsService.prototype.handleError=function(error){var errMsg=error.message?error.message:error.status?error.status+" - "+error.statusText:"Server error";return console.error(errMsg),Observable_1.Observable.throw(errMsg)},WorldDetailsService=__decorate([core_1.Injectable(),__metadata("design:paramtypes",[http_1.Http])],WorldDetailsService)}(),exports_1("WorldDetailsService",WorldDetailsService)}}});
//# sourceMappingURL=worldDetails.service.js.map
