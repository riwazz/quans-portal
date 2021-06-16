import { Sonuc } from './../../models/Sonuc';
import { Yorum } from './../../models/Yorum';
import { ApiService } from 'src/app/services/api.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Makale } from 'src/app/models/Makale';

@Component({
  selector: 'app-makale',
  templateUrl: './makale.component.html',
  styleUrls: ['./makale.component.scss']
})
export class MakaleComponent implements OnInit {
  makaleId: number;
  makale: Makale;
  yorumlar: Yorum[];
  constructor(
    public apiServis: ApiService,
    public route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      if (p.makaleId) {
        this.makaleId = p.makaleId;
        this.MakaleById();
        this.MakaleYorumListe();
      }

    });
  }

  MakaleById() {
    this.apiServis.MakaleById(this.makaleId).subscribe((d: Makale) => {
      this.makale = d;
      this.MakaleOkunduYap();
    });
  }
  MakaleOkunduYap() {
    this.makale.Okunma += 1;
    this.apiServis.MakaleDuzenle(this.makale).subscribe();
  }

  MakaleYorumListe() {
    this.apiServis.YorumListeBymakaleId(this.makaleId).subscribe((d: Yorum[]) => {
      this.yorumlar = d;
    });
  }

  YorumEkle(yorumMetni: string) {
    var yorum: Yorum = new Yorum();
    var uyeId: number = parseInt(localStorage.getItem("uid"));
    yorum.MakaleId = this.makaleId;
    yorum.UyeId = uyeId;
    yorum.YorumIcerik = yorumMetni;
    yorum.Tarih = new Date();

    this.apiServis.YorumEkle(yorum).subscribe((d: Sonuc) => {
      if (d.islem) {
        this.MakaleYorumListe();
      }
    });
  }
}
