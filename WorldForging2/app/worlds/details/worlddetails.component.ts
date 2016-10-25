import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { World } from '../world.ts';
import { WorldDetailsService } from '../services/worldDetails.service';

import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'worlddetails',
    templateUrl: '/app/worlds/details/worlddetails.component.template.html',
    providers: [WorldDetailsService]
})

export class WorldDetails implements OnInit {
    errorMessage: string;
    world: World;
    mode = 'Observable';
    worldId: Number;
    private sub: any;
    constructor(private worldDetailsService: WorldDetailsService, private route: ActivatedRoute) { }
    ngOnInit() {
        
        this.sub = this.route.params.subscribe(params => {
            this.worldId = +params['id']; // (+) converts string 'id' to a number
            this.getWorldDetails(this.worldId);
        });
    }
    getWorldDetails(worldId : Number) {
        this.worldDetailsService.getWorldDetails(worldId)
            .subscribe(
            world => this.world = world,
            error => this.errorMessage = <any>error);
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
}