import { ProdutoService } from './../produtos.service';
import { Component, OnInit } from '@angular/core';
import { Produto } from '../produto';

@Component({
  selector: 'app-lista-produto',
  templateUrl: './lista-produto.component.html'
})
export class ListaProdutoComponent implements OnInit{

  constructor(private produtoService: ProdutoService) { }

  public produtos: Produto[];

  ngOnInit(): void {
      this.produtoService.obterProdutos()
      .subscribe({
        next: produtos => {
          this.produtos = produtos;
          console.log(produtos);          
        },
        error : e => console.log(e)        
      })
  }

  // Quando o componente estiver pronto, vai chamar o obterProdutos e vai popular a coleção de produtos e exibir no template.
  

}
