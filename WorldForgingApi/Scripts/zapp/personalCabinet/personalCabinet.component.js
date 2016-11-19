System.register(['@angular/core', '../usefullLinksService/usefulllink.service'], function(exports_1, context_1) {
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
    var core_1, usefulllink_service_1;
    var PersonalCabinet;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (usefulllink_service_1_1) {
                usefulllink_service_1 = usefulllink_service_1_1;
            }],
        execute: function() {
            PersonalCabinet = (function () {
                function PersonalCabinet(linkService) {
                    this.linkService = linkService;
                    this._usefullLinkService = linkService;
                }
                Object.defineProperty(PersonalCabinet.prototype, "LinkList", {
                    get: function () { return this._linkList; },
                    enumerable: true,
                    configurable: true
                });
                PersonalCabinet.prototype.ngOnInit = function () {
                    this._linkList = this._usefullLinkService.GetLinks();
                };
                PersonalCabinet = __decorate([
                    core_1.Component({
                        selector: 'personal-cabinet',
                        templateUrl: '/Scripts/app/personalCabinet/personalCabinet.component.template.html',
                        providers: [usefulllink_service_1.UsefullLinkService]
                    }), 
                    __metadata('design:paramtypes', [usefulllink_service_1.UsefullLinkService])
                ], PersonalCabinet);
                return PersonalCabinet;
            }());
            exports_1("PersonalCabinet", PersonalCabinet);
        }
    }
});
