import{_ as u,a as _,A as i}from"./index.ebefc692.js";import{u as m,s as p,E as v,c as d,o as a,b as o,d as t,z as r,t as l,F as h,y,p as g,j as f,x as b}from"./vendor.e937b152.js";const V={name:"Account",setup(){m();const e=p();return v(async()=>{await _.getMyVaults()}),{routerLink(n){e.push({name:"Vault",params:{id:n}})},account:d(()=>i.account),myVaults:d(()=>i.myVaults)}}},k=e=>(g("data-v-7e15560c"),e=e(),f(),e),x={class:"container-fluid"},w={class:"row h-50"},S={class:"col-md-12 my-2"},A=k(()=>t("button",{class:"btn btn-outline-primary mdi mdi-plus",title:"create vault","data-bs-toggle":"modal","data-bs-target":"#createVault-modal"},null,-1)),j={class:"col-md-12 d-flex"},C={class:"row"},I=["onClick"],B={class:"card-body d-flex align-items-end justify-content-between"},L={key:0,class:"mdi mdi-star text-success",title:"This is a private vault"};function N(e,n,P,c,z,E){return a(),o("div",x,[t("div",w,[t("div",S,[A,r(" Vaults: "+l(c.myVaults.length),1)]),t("div",j,[t("div",C,[(a(!0),o(h,null,y(c.myVaults,s=>(a(),o("div",{class:"col-md-2",style:{width:"18rem"},key:s.id},[t("div",{class:"card m-2 sizing bg-dark action",title:"Click to open vault",onClick:F=>c.routerLink(s.id)},[t("div",B,[r(l(s.name)+" ",1),s.isPrivate?(a(),o("i",L)):b("",!0)])],8,I)]))),128))])])])])}var T=u(V,[["render",N],["__scopeId","data-v-7e15560c"]]);export{T as default};