System.register(["@angular/core", "../services/worldDetails.service", "@angular/router"], function (exports_1, context_1) {
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
    var core_1, worldDetails_service_1, router_1, WorldDetails;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (worldDetails_service_1_1) {
                worldDetails_service_1 = worldDetails_service_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            }
        ],
        execute: function () {
            WorldDetails = (function () {
                function WorldDetails(worldDetailsService, route) {
                    this.worldDetailsService = worldDetailsService;
                    this.route = route;
                    this.mode = 'Observable';
                }
                WorldDetails.prototype.ngOnInit = function () {
                    var _this = this;
                    this.sub = this.route.params.subscribe(function (params) {
                        _this.worldId = +params['id']; // (+) converts string 'id' to a number
                        _this.getWorldDetails(_this.worldId);
                    });
                };
                WorldDetails.prototype.getWorldDetails = function (worldId) {
                    var _this = this;
                    this.worldDetailsService.getWorldDetails(worldId)
                        .subscribe(function (world) { return _this.world = world; }, function (error) { return _this.errorMessage = error; });
                };
                //addWorld(name: string) {
                //    if (!name) { return; }
                //    this.worldListService.addWorld(name)
                //        .subscribe(
                //        world => this.worlds.push(world),
                //        error => this.errorMessage = <any>error);
                //}
                WorldDetails.prototype.ngOnDestroy = function () {
                    this.sub.unsubscribe();
                };
                return WorldDetails;
            }());
            WorldDetails = __decorate([
                core_1.Component({
                    selector: 'worlddetails',
                    templateUrl: '/Scripts/app/worlds/details/worlddetails.component.template.html',
                    providers: [worldDetails_service_1.WorldDetailsService]
                }),
                __metadata("design:paramtypes", [worldDetails_service_1.WorldDetailsService, router_1.ActivatedRoute])
            ], WorldDetails);
            exports_1("WorldDetails", WorldDetails);
        }
    };
});
