System.register(['@angular/core', '../services/worldList.service'], function(exports_1, context_1) {
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
    var core_1, worldList_service_1;
    var Worlds;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (worldList_service_1_1) {
                worldList_service_1 = worldList_service_1_1;
            }],
        execute: function() {
            Worlds = (function () {
                function Worlds(worldListService) {
                    this.worldListService = worldListService;
                    this.mode = 'Observable';
                }
                Worlds.prototype.ngOnInit = function () { this.getWorlds(); };
                Worlds.prototype.getWorlds = function () {
                    var _this = this;
                    this.worldListService.getWorlds()
                        .subscribe(function (worlds) { return _this.worlds = worlds; }, function (error) { return _this.errorMessage = error; });
                };
                Worlds = __decorate([
                    core_1.Component({
                        selector: 'worlds',
                        templateUrl: '/Scripts/app/worlds/index/worlds.component.template.html',
                        providers: [worldList_service_1.WorldListService]
                    }), 
                    __metadata('design:paramtypes', [worldList_service_1.WorldListService])
                ], Worlds);
                return Worlds;
            }());
            exports_1("Worlds", Worlds);
        }
    }
});
