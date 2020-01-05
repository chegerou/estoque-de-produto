import { Component, OnInit } from '@angular/core';
import { Produto } from '../src/model/Produto';
import { EstoqueProdutoService } from '../src/service/estoque-produto.service';
import { error } from 'protractor';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  id: number
  preco: number;
  quantidade: number;
  nome: string = '';

  produto: Produto[] = [];

  produtoEdit: Produto = null;

  constructor(private EstoqueProdutoService: EstoqueProdutoService) { }

  ngOnInit() {
    this.carregarProdutos();
  }

  save() {
    if (this.produtoEdit) {
      this.produtoEdit.nome = this.nome;
      this.produtoEdit.preco = this.preco
      this.produtoEdit.quantidade = this.quantidade;
      this.EstoqueProdutoService.putProduto(this.produtoEdit)
        .subscribe((prod) => {
          console.log(prod);
        },
          (error) => {
            console.log(error);
          })
    }
    else {
      let novoProduto: Produto = {
        id: null,
        nome: this.nome,
        preco: this.preco,
        quantidade: this.quantidade
      };

      this.EstoqueProdutoService.postProdutos(novoProduto)
        .subscribe((data) => {
          this.limparCampos()
        },
          (error) => console.log(error)
        )

    }
  }

  edit(pro: Produto) {
    this.nome = pro.nome;
    this.preco = pro.preco;
    this.quantidade = pro.quantidade;
    this.produtoEdit = pro;
  }

  delete(prod: Produto) {
    this.EstoqueProdutoService.deleteProduto(prod)
      .subscribe(() => {
        console.log("Produto foi deletado");
        this.carregarProdutos();
      },
        (error) => {
          console.log(error);
        })
    
  }

  limparCampos() {
    this.id = null
    this.preco = null;
    this.quantidade = null;
    this.nome = '';
    this.produtoEdit = null;
  }

  carregarProdutos(){
    this.EstoqueProdutoService.getProdutos()
    .subscribe((data) => {
      console.log(data);
      this.produto = data;
      console.log(this.produto);
    }, (error) => {
      console.log(error);
    });
  }

}
