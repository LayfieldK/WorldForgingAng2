﻿import { EntityRelationship } from "./entity-relationship";

export class Article {
    constructor(
        public Id: number,
        public Title: string,
        public Description: string,
        public Text: string,
        public EntityRelationships: EntityRelationship[]
    ) { }
}
