import { Component, OnInit } from '@angular/core';
import { CategoriaService } from '../categoria.service';
import { Categoria } from '../categoria';

@Component({
  selector: 'app-lista-categoria',
  templateUrl: './lista-categoria.component.html'
})
export class ListaCategoriaComponent implements OnInit {

  constructor(private categoriaService: CategoriaService) { }

  public categorias: Categoria[];

  ngOnInit(): void {

    this.categoriaService.obterCategoria()
      .subscribe({
        next: categorias => {
          this.categorias = categorias;
          console.log(categorias);
        },
        error: e => console.log(e)
      })
  }
}
