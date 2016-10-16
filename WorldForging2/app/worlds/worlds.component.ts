import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { World } from '../worldListService/world.ts';
import { WorldListService } from '../worldListService/worldList.service';

@Component({
    selector: 'worlds',
    templateUrl: '/app/worlds/worlds.component.template.html',
    providers: [WorldListService]
})

export class Worlds implements OnInit {
    errorMessage: string;
    worlds: World[];
    mode = 'Observable';
    constructor(private worldListService: WorldListService) { }
    ngOnInit() { this.getWorlds(); }
    getWorlds() {
        this.worldListService.getWorlds()
            .subscribe(
            worlds => this.worlds = worlds,
            error => this.errorMessage = <any>error);
    }
    //addWorld(name: string) {
    //    if (!name) { return; }
    //    this.worldListService.addWorld(name)
    //        .subscribe(
    //        world => this.worlds.push(world),
    //        error => this.errorMessage = <any>error);
    //}
}