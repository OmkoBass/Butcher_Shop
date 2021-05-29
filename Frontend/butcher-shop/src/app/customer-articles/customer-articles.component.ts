import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Location } from "@angular/common";
import { CustomerService } from '../services/customerService/customer.service';
import { ArticleService } from '../services/articleService/article.service';

@Component({
  selector: 'app-customer-articles',
  templateUrl: './customer-articles.component.html',
  styleUrls: ['./customer-articles.component.css']
})
export class CustomerArticlesComponent implements OnInit {
  loading = true;
  customer = null;
  searchArticlesValue = null;
  submitting = false;

  constructor(
    private router: Router,
    private location: Location,
    private customerService: CustomerService,
    private articleService: ArticleService,
    private snackBar: MatSnackBar,
  ) { }

  ngOnInit(): void {
    const urlParam = this.router.url.split("/")[2];

      this.customerService.GetCustomer(urlParam)
      .subscribe(res => {
        this.customer = res;
        this.loading = false;
      }, () => {
        this.snackBar.open('Something went wrong!', 'Okay!')
        this.loading = false;
      });
  }

  handleDeleteArticle(id: string) {
    this.submitting = true;
    this.articleService.DeleteArticle(id)
    .subscribe(_ => {
      this.customer.boughtArticles = this.customer.boughtArticles.filter(article => article.id !== id);
      this.snackBar.open('Article Deleted!', 'Okay!');
      this.submitting = false;
    }, () => {
      this.snackBar.open('Something went wrong!', 'Okay!');
      this.submitting = false;
    });
  }

  handleSearchArticles(value) {
    this.searchArticlesValue = value;
  }

  handleGoBack() {
    this.location.back();
  }
}
