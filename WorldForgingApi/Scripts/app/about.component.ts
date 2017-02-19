import {Component} from "@angular/core";

@Component({
    selector: "about",
    template: `
        <h2>{{title}}</h2>
        <div>
            World Forging: a world building tool that allows you to create relationships between characters, locations, events, and stories.
        </div>
    `
})

export class AboutComponent {
    title = "About";
}
