import { Filme } from "./filme.model";
import { Sala } from "./sala.model";

export interface Exibicao{
    exibicaoId?: number;
    dataHora: string;
    filme?: Filme;
    filmeId: number;
    sala?: Sala;
    salaId: number;
}