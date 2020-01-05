import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { Produto } from '../model/Produto';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EstoqueProdutoService {

  readonly url = 'https://localhost:44352/api/EstoqueProduto';
  private produtoSubject$: BehaviorSubject<Produto[]> = new BehaviorSubject<Produto[]>(null);
  private loading: boolean = false;


  constructor(private http: HttpClient) { }

  getProdutos(): Observable<Produto[]> {
    if (!this.loading) {
      this.http.get<Produto[]>(`${this.url}/GetProdutos`)
        .subscribe(this.produtoSubject$);
      this.loading = true;
    }
    return this.produtoSubject$.asObservable();
  }

  postProdutos(prod: Produto): Observable<Produto> {
    return this.http.post<Produto>(`${this.url}/PostProduto`, prod)
      .pipe(
          tap((prod: Produto) => this.produtoSubject$.getValue().push(prod))
      );
  }

  putProduto(prod: Produto): Observable<Produto> {
    return this.http.put<Produto>(`${this.url}/PutProduto`, prod)
    .pipe(
      tap(mensagem => {
        let produtos = this.produtoSubject$.getValue();
        let indice = produtos.findIndex(d => d.id === prod.id);
        if(indice>=0)
          produtos[indice].id = prod.id;
          produtos[indice].preco = prod.preco;
          produtos[indice].quantidade = prod.quantidade;
          produtos[indice].nome = prod.nome;
      })
    )
  }

  deleteProduto(prod: Produto): Observable<any> {
    return this.http.delete<any>(`${this.url}/DeleteProduto?idProduto=${prod.id}`)
    .pipe(
      tap((res) => {
        let x = res;
        let produtos = this.produtoSubject$.getValue();
        let indice = produtos.findIndex(d => d.id === prod.id);
        if(indice>=0)
          produtos.splice(indice,1);
      })
    )
  }
}
