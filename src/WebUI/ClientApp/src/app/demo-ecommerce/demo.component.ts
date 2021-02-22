import { Component, TemplateRef } from '@angular/core';
import {
  ManageProductsClient, CreateProductCommand, UpdateProductCommand, ProductsVm, ProductDto, CategoriesClient, CreateCategoryCommand, UpdateCategoryCommand, ProductsInCategoryDto, Product
} from '../web-api-client';
import { faPlus, faEllipsisH } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-demo-component',
  templateUrl: './demo.component.html',
  styleUrls: ['./demo.component.scss']
})
export class DemoComponent {

  debug = false;

  vm: ProductsVm;

  selectedList: ProductsInCategoryDto;
  selectedItem: ProductDto;

  newListEditor: any = {};
  listOptionsEditor: any = {};
  itemDetailsEditor: any = {};

  newListModalRef: BsModalRef;
  listOptionsModalRef: BsModalRef;
  deleteListModalRef: BsModalRef;
  itemDetailsModalRef: BsModalRef;

  faPlus = faPlus;
  faEllipsisH = faEllipsisH;

  constructor(private categoriesClient: CategoriesClient, private productClient: ManageProductsClient, private modalService: BsModalService) {
    categoriesClient.get().subscribe(
      result => {
        this.vm = result;
        if (this.vm.lists.length) {
          this.selectedList = this.vm.lists[0];
        }
      },
      error => console.error(error)
    );
  }

  // Categories

  showNewListModal(template: TemplateRef<any>): void {
    this.newListModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById("title").focus(), 250);
  }

  newListCancelled(): void {
    this.newListModalRef.hide();
    this.newListEditor = {};
  }

  addCategory(): void {
    let list = ProductsInCategoryDto.fromJS({
      id: 0,
      name: this.newListEditor.name,
      products: []
    });

    this.categoriesClient.create(<CreateCategoryCommand>{ name: this.newListEditor.name }).subscribe(
      result => {
        list.id = result;
        this.vm.lists.push(list);
        this.selectedList = list;
        this.newListModalRef.hide();
        this.newListEditor = {};
      },
      error => {
        let errors = JSON.parse(error.response);

        if (errors && errors.Title) {
          this.newListEditor.error = errors.Title[0];
        }

        setTimeout(() => document.getElementById("name").focus(), 250);
      }
    );
  }

  showListOptionsModal(template: TemplateRef<any>) {
    this.listOptionsEditor = {
      id: this.selectedList.id,
      name: this.selectedList.name,
      seoAlias: this.selectedList.seoAlias,
      seoDescription: this.selectedList.seoDescription,
      seoTitle: this.selectedList.seoTitle,
    };

    this.listOptionsModalRef = this.modalService.show(template);
  }

  updateListOptions() {
    this.categoriesClient.update(this.selectedList.id, UpdateCategoryCommand.fromJS(this.listOptionsEditor))
      .subscribe(
        () => {
          this.selectedList.name = this.listOptionsEditor.name, this.listOptionsModalRef.hide();
          this.selectedList.seoAlias = this.listOptionsEditor.seoAlias, this.listOptionsModalRef.hide();
          this.selectedList.seoDescription = this.listOptionsEditor.seoDescription, this.listOptionsModalRef.hide();
          this.selectedList.seoTitle = this.listOptionsEditor.seoTitle, this.listOptionsModalRef.hide();

          this.listOptionsEditor = {};
        },
        error => console.error(error)
      );
  }

  confirmDeleteList(template: TemplateRef<any>) {
    this.listOptionsModalRef.hide();
    this.deleteListModalRef = this.modalService.show(template);
  }

  deleteListConfirmed(): void {
    this.categoriesClient.delete(this.selectedList.id).subscribe(
      () => {
        this.deleteListModalRef.hide();
        this.vm.lists = this.vm.lists.filter(t => t.id != this.selectedList.id)
        this.selectedList = this.vm.lists.length ? this.vm.lists[0] : null;
      },
      error => console.error(error)
    );
  }

  // Products In Category

  showItemDetailsModal(template: TemplateRef<any>, item: ProductDto): void {
    this.selectedItem = item;
    this.itemDetailsEditor = {
      ...this.selectedItem
    };

    this.itemDetailsModalRef = this.modalService.show(template);
  }

  addProduct() {
    let item = ProductDto.fromJS({
      id: 0,
      listId: this.selectedList.id,
      price: 0,
      name: ''
    });

    this.selectedList.products.push(item);
    let index = this.selectedList.products.length - 1;
    this.editProduct(item, 'itemTitle' + index);
  }

  editProduct(item: ProductDto, inputId: string): void {
    this.selectedItem = item;
    setTimeout(() => document.getElementById(inputId).focus(), 100);
  }

  updateProduct(item: ProductDto, pressedEnter: boolean = false): void {
    let id = item.productTranslations[0].id;
    let isNewItem = id == 0;

    if (!item.productTranslations[0].name.trim()) {
      this.deleteProduct(item);
      return;
    }

    if (id== 0) {
      this.productClient.create(CreateProductCommand.fromJS({ ...item, listId: this.selectedList.id }))
        .subscribe(
          result => {
            id = result;
          },
          error => console.error(error)
        );
    } else {
      this.productClient.update(id, UpdateProductCommand.fromJS(item))
        .subscribe(
          () => console.log('Update succeeded.'),
          error => console.error(error)
        );
    }

    this.selectedItem = null;

    if (isNewItem && pressedEnter) {
      this.addProduct();
    }
  }

  // Delete product
  deleteProduct(item: ProductDto) {
    if (this.itemDetailsModalRef) {
      this.itemDetailsModalRef.hide();
    }
    let id = item.productTranslations[0].id;
    if (id == 0) {
      let itemIndex = this.selectedList.products.indexOf(this.selectedItem);
      this.selectedList.products.splice(itemIndex, 1);
    } else {
      this.productClient.delete(id).subscribe(
        () => this.selectedList.products = this.selectedList.products.filter(t => t.productTranslations[0].id != id),
        error => console.error(error)
      );
    }
  }
}
