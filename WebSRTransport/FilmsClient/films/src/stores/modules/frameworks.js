let index = 1;
let frameworkTypes = [
    { id: 1, name: "css" },
    { id: 2, name: "js" },
    { id: 3, name: "asp" }
];
let frameworks = [
    { id: index++, name: "Bootstrap", type: frameworkTypes[0] },
    { id: index++, name: "Materialize", type: frameworkTypes[0] },
    { id: index++, name: "Vue", type: frameworkTypes[1] },
];
frameworks.forEach(x=>x.Active = false);
frameworks[0].Active = true;

export default {
    state: {
        frameworks,
        frameworkTypes
    },
    getters: {
        getFrameworks(state){
            return state.frameworks;
        },
        getFrameworkTypes(state){
            return state.frameworkTypes;
        },
        getActiveFramework(state){
            return state.frameworks.find(x=>x.Active);
        },
        getFramework(state, id){
            return state.frameworks.find(x=>x.id === id);
        }
    },
    actions: {
        async setActiveFramework(ctx, id){
            ctx.commit('setActive', id);
        },
    },
    mutations: {
        setActive(state, id){
            state.frameworks.forEach(x=>x.Active = false);
            let framework = state.frameworks.find(x=>x.id == id);
            
            if (framework)
                framework.Active = true;
        },
    }
}