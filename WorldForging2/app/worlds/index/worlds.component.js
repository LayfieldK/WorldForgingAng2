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
const worldList_service_1 = require('../services/worldList.service');
let Worlds = class Worlds {
    constructor(worldListService) {
        this.worldListService = worldListService;
        this.mode = 'Observable';
    }
    ngOnInit() { this.getWorlds(); }
    getWorlds() {
        this.worldListService.getWorlds()
            .subscribe(worlds => this.worlds = worlds, error => this.errorMessage = error);
    }
};
Worlds = __decorate([
    core_1.Component({
        selector: 'worlds',
        templateUrl: '/app/worlds/index/worlds.component.template.html',
        providers: [worldList_service_1.WorldListService]
    }), 
    __metadata('design:paramtypes', [worldList_service_1.WorldListService])
], Worlds);
exports.Worlds = Worlds;
//# sourceMappingURL=worlds.component.js.map