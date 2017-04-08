import { EntityRelationship } from "./entity-relationship";

export class Entity {
    constructor(
        public Id: number,
        public Name: string,
        public EntityRelationships: EntityRelationship[]
    ) { }
}
