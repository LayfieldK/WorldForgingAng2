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
const core_1 = require('@angular/core');
const worldDetails_service_1 = require('../services/worldDetails.service');
const router_1 = require('@angular/router');
let WorldDetails = class WorldDetails {
    constructor(worldDetailsService, route) {
        this.worldDetailsService = worldDetailsService;
        this.route = route;
        this.mode = 'Observable';
    }
    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.worldId = +params['id']; // (+) converts string 'id' to a number
            this.getWorldDetails(this.worldId);
        });
    }
    getWorldDetails(worldId) {
        this.worldDetailsService.getWorldDetails(worldId)
            .subscribe(world => this.world = world, error => this.errorMessage = error);
    }
    //addWorld(name: string) {
    //    if (!name) { return; }
    //    this.worldListService.addWorld(name)
    //        .subscribe(
    //        world => this.worlds.push(world),
    //        error => this.errorMessage = <any>error);
    //}
    ngOnDestroy() {
        this.sub.unsubscribe();
    }
};
WorldDetails = __decorate([
    core_1.Component({
        selector: 'worlddetails',
        templateUrl: '/app/worlds/details/worlddetails.component.template.html',
        providers: [worldDetails_service_1.WorldDetailsService]
    }), 
    __metadata('design:paramtypes', [worldDetails_service_1.WorldDetailsService, router_1.ActivatedRoute])
], WorldDetails);
exports.WorldDetails = WorldDetails;
//# sourceMappingURL=worlddetails.component.js.map