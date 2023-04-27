import { DataBindingComponent } from './demos/data-binding/data-binding.component';
import { Routes } from "@angular/router"
import { HomeComponent } from "./navegacao/home/home.component";
import { ContatoComponent } from "./institucional/contato/contato.component";
import { SobreComponent } from "./institucional/sobre/sobre.component";

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full'}, // Redirecionando para a página home por padrão
    { path: 'home', component: HomeComponent },
    { path: 'contato', component: ContatoComponent },
    { path: 'sobre', component: SobreComponent }, 
    { path: 'featured-data-binding', component: DataBindingComponent }, 
];