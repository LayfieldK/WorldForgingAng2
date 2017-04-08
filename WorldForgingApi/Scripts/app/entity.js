System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Entity;
    return {
        setters: [],
        execute: function () {
            Entity = (function () {
                function Entity(Id, Name, EntityRelationships) {
                    this.Id = Id;
                    this.Name = Name;
                    this.EntityRelationships = EntityRelationships;
                }
                return Entity;
            }());
            exports_1("Entity", Entity);
        }
    };
});
