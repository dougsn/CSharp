import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Categoria } from './categoria';
import { Injectable } from '@angular/core';


@Injectable()
export class CategoriaService {

    constructor(private http: HttpClient){}

    protected urlServiceV1: string = "http://localhost:5500/";

    obterCategoria() : Observable<Categoria[]> {
        return this.http
        .get<Categoria[]>(this.urlServiceV1 + "categoria")
    }



}