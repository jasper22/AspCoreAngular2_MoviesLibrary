import { Component, Input, OnInit} from "@angular/core";
import { Router           } from "@angular/router";
import { Item             } from "./Item";
import { ItemService      } from "./Item.Service";

@Component({
        moduleId: module.id,    // fully resolved filename; defined at module load time
        selector: "item-list",
        template: `
                    <h2>{{class}}:</h2>
                    <ul class="items">
                        <li *ngFor="let item of itemsCollection" 
                                [class.selected]="item === selectedItem" 
                                (click)="onSelect(item)">
                            <span>{{item.Title}}</span>
                        </li>
                    </ul>
                    <item-detail *ngIf="selectedItem" [currentItem]="selectedItem"></item-detail>
                  `
        ,
        styles: [`
                    ul.items li {
                        cursor: pointer;
                    }

                    ul.items li.selected {
                        background-color: #cccccc;
                    }
                `]

    })

///
/// The <c>ItemListComponent</c> class
export class ItemListComponent implements OnInit {
    selectedItem: Item;
    @Input() class: string;
    title: string;
    itemsCollection: Array<Item> = [];
    errorMessage: string;

        //
        // Constructor
        // Must receive 'ItemService' and 'Router'
        constructor(private itemService: ItemService, private router: Router) {
        }

        //
        // Overloaded ngOnInit function
        ngOnInit() {
            console.log("ItemListComponent instantiated with the following class: " + this.class);

            var s = null;
            switch (this.class) {

                case "latest":
                default:
                    this.title = "Latest Items";
                    s = this.itemService.getLatest();
                    break;

                case "most-viewed":
                    this.title = "Most Viewed Items";
                    s = this.itemService.getMostViewed();
                    break;

                case "random":
                    this.title = "Random Items";
                    s = this.itemService.getRandom();
                    break;
            }

            s.subscribe(
                items => {
                    console.log("ItemListComponent: received collection: " + items);
                    this.itemsCollection = items;
                },
                error => {
                    this.errorMessage = <any>error
                    console.log("ItemListComponent: Error ! = " + this.errorMessage);
                }
            );
        }

        //
        // Function will return an Observable collection that 
        // pull 'latest' items via itemService
        getLatest() {
            this.itemService.getLatest()
                .subscribe(
                    latestItems => {
                        this.itemsCollection = latestItems;
                    },
                    error => this.errorMessage = <any>error
                );
        }

        // 
        // Function will handle 'on item selected' event
        onSelect(item: Item) {
            //this.selectedItem = item;
            //console.log("item with Id " + this.selectedItem.Id + " has been selected.");

            this.selectedItem = item;

            console.log("Item " + this.selectedItem.Id + " has been clicked: loading ItemDetailComponent...");

            this.router.navigate(["item", this.selectedItem.Id]);
        }
    }