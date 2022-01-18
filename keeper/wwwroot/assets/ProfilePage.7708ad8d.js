import{u as y,s as b,E as k,M as w,c as l,o as d,b as c,d as e,t as n,x as u,F as f,y as g,z as v,i as V,G as P}from"./vendor.e937b152.js";import{b as p,l as _,A as a,_ as x,a as K,k as B,P as I}from"./index.ebefc692.js";class C{async getVaultsByProfileId(o){const s=await p.get(`/api/profiles/${o}/vaults`);_.log("Get vaults by profile id",s.data),a.profileVaults=s.data}async getKeepsByProfileId(o){const s=await p.get(`/api/profiles/${o}/keeps`);_.log("Get keeps by profile id",s.data),a.profileKeeps=s.data}async getUserProfile(o){const s=await p.get(`/api/profiles/${o}`);_.log("Get user profile",s.data),a.profile=s.data}}const m=new C;const S={name:"ProfilePage",setup(){const r=y(),o=b();return k(async()=>{await m.getUserProfile(r.params.id),await m.getVaultsByProfileId(r.params.id),await m.getKeepsByProfileId(r.params.id),await K.getAccount()}),{routerLink(s){o.push({name:"Vault",params:{id:s}})},async setActive(s){try{a.activeKeep=s,await B.getKeepById(s.id)}catch(t){_.error(t),w.getOrCreateInstance(document.getElementById("keep-modal")).hide(),I.toast(t,"error")}},router:o,route:r,keeps:l(()=>a.keeps),activeVault:l(()=>a.activeVault),vaults:l(()=>a.vaults),profileVaults:l(()=>a.profileVaults),profileKeeps:l(()=>a.profileKeeps),profile:l(()=>a.profile),account:l(()=>a.account)}}},A={class:"container-fluid"},z={class:"row h-50"},G={class:"col-md-12 my-4",style:{height:"15rem"}},M={class:"row ms-2"},E={class:"col-md-1"},L=["src"],N={class:"col-md-11 d-flex flex-column"},j={class:"row"},F={class:"col-md-12"},R={class:"row my-3"},U={class:"col-md-12"},D={class:"col-md-12"},O={class:"col-md-12 my-2 ms-2"},T=v(" Vaults "),q={key:0,class:"btn btn-outline-primary mdi mdi-plus",title:"create vault","data-bs-toggle":"modal","data-bs-target":"#createVault-modal"},H={class:"col-md-12 d-flex"},J={class:"row"},Q=["onClick"],W={class:"card-body d-flex align-items-end"},X={class:"col-md-12 my-2 ms-2"},Y=v(" Keeps "),Z={key:0,class:"btn btn-outline-primary mdi mdi-plus",title:"create keep","data-bs-toggle":"modal","data-bs-target":"#createKeep-modal"},$={class:"col-md-12 d-flex"},ee={class:"row"},te=["onClick"];function se(r,o,s,t,ae,oe){return d(),c("div",A,[e("div",z,[e("div",G,[e("div",M,[e("div",E,[e("img",{src:t.profile.picture,alt:""},null,8,L)]),e("div",N,[e("div",j,[e("div",F,n(t.profile.name),1)]),e("div",R,[e("div",U,[e("p",null," Vaults: "+n(t.profileVaults.length),1)]),e("div",D,[e("p",null," Keeps: "+n(t.profileKeeps.length),1)])])])])]),e("div",O,[T,t.account.id==t.route.params.id?(d(),c("button",q)):u("",!0)]),e("div",H,[e("div",J,[(d(!0),c(f,null,g(t.profileVaults,i=>(d(),c("div",{class:"col-md-2",style:{width:"18rem"},key:i.id},[e("div",{class:"card m-2 bg-dark sizing action",title:"Click to open vault",style:{},onClick:h=>t.routerLink(i.id)},[e("div",W,n(i.name),1)],8,Q)]))),128))])]),e("div",X,[Y,t.account.id==t.route.params.id?(d(),c("button",Z)):u("",!0)]),e("div",$,[e("div",ee,[(d(!0),c(f,null,g(t.profileKeeps,i=>(d(),c("div",{class:"col-md-2",style:{width:"18rem"},key:i.id},[e("div",{class:"card m-2 bg-dark sizing action",title:"Click to open keep","data-bs-toggle":"modal","data-bs-target":"#keep-modal",onClick:V(h=>t.setActive(i),["stop"])},[e("div",{class:"card-body d-flex align-items-end",style:P({backgroundImage:`url(${i.img})`})},n(i.name),5)],8,te)]))),128))])])])])}var de=x(S,[["render",se],["__scopeId","data-v-004379cc"]]);export{de as default};
