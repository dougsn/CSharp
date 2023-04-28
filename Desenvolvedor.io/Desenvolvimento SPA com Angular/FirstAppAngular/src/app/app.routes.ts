import { DataBindingComponent } from './demos/data-binding/data-binding.component';
import { Routes } from "@angular/router"
import { HomeComponent } from "./navegacao/home/home.component";
import { ContatoComponent } from "./institucional/contato/contato.component";
import { SobreComponent } from "./institucional/sobre/sobre.component";
import { ListaProdutoComponent } from './produtos/lista-produto/lista-produto.component';
import { ListaCategoriaComponent } from './categorias/lista-categoria/lista-categoria.component';

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full'}, // Redirecionando para a página home por padrão
    { path: 'home', component: HomeComponent },
    { path: 'contato', component: ContatoComponent },
    { path: 'sobre', component: SobreComponent }, 
    { path: 'featured-data-binding', component: DataBindingComponent }, 
    { path: 'produtos', component: ListaProdutoComponent }, 
    { path: 'produto-detalhe/:id', component: ListaProdutoComponent }, 
    { path: 'categoria', component: ListaCategoriaComponent }, 
];