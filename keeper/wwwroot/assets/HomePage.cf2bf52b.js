import{u as l,s as p,E as _,c as e,a as d,o as s,b as c,d as i,F as m,y as v,g as f}from"./vendor.e937b152.js";import{_ as k,k as y,A as t}from"./index.ebefc692.js";const g={name:"Home",setup(){const a=l(),o=p();return _(async()=>{await y.getAllKeeps()}),{router:o,route:a,account:e(()=>t.account),keeps:e(()=>t.keeps),activeVault:e(()=>t.activeVault),vaults:e(()=>t.vaults),myVaults:e(()=>t.myVaults)}}},x={class:"flex-grow-1 d-flex flex-column align-items-center justify-content-center container-fluid mt-3"},V={class:"masonry-with-columns"};function b(a,o,h,r,B,j){const u=d("Keeps");return s(),c("div",x,[i("div",V,[(s(!0),c(m,null,v(r.keeps,n=>(s(),f(u,{key:n.id,keep:n},null,8,["keep"]))),128))])])}var H=k(g,[["render",b],["__scopeId","data-v-cdb8d748"]]);export{H as default};
