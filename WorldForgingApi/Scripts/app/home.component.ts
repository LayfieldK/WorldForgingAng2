import {Component} from "@angular/core";

@Component({
    selector: "home",
    template: `
<h2>
    A world building tool for creating relationships between your characters, locations, events, and stories.
</h2>
<div class="col-md-4">
    <article-list class="latest"></article-list>
</div>
<div class="col-md-4">
    <article-list class="most-viewed"></article-list>
</div>
<div class="col-md-4">
    <article-list class="random"></article-list>
</div>
    `,
    styles: []
})

export class HomeComponent {
    title = "Welcome View";
}
