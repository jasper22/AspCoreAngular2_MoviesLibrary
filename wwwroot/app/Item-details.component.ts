import { Router, ActivatedRoute} from "@angular/router";
import { Component, Input      } from "@angular/core";
import { Item                  } from "./Item";
import { ItemService           } from "./Item.Service";

@Component({
    selector: "item-detail",
    template: `
            <div *ngIf="currentItem" class="item-details">
                <h2>{{currentItem.Title}} - Detail View</h2>
                <ul>
                    <li>
                        <label>Title:</label>
                        <input [(ngModel)]="currentItem.Title" placeholder="Insert the title..."/>
                    </li>
                    <li>
                        <label>Description:</label>
                        <textarea [(ngModel)]="currentItem.Description" placeholder="Insert a suitable description..."></textarea>
                    </li>
                </ul>
            </div>`
    ,
    styles: [`
            .item-details {
                margin: 5px;
                padding: 5px 10px;
                border: 1px solid black;
                background-color: #dddddd;
                width: 300px;
            }

            .item-details * {
                vertical-align: middle;
            }

            .item-details ul li {
                padding: 5px 0;
            }
            `],
    inputs: ['currentItem'],

})

export class ItemDetailsComponent {
    //@Input("item") item: Item;

    public currentItem: Item;

    //private currentItem: Item;
    //@Input()
    //set item(newItem: Item) {
    //    if (newItem != null) {
    //        this.currentItem = newItem;
    //    }
    //}
    //get item() {
    //    return this.currentItem;
    //}

    constructor(private itemService: ItemService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        var id = +this.activatedRoute.snapshot.params["id"];
        if (id) {
            this.itemService.get(id).subscribe(
                item => this.currentItem = item
            );
        }
        else {
            console.log("Invalid id: routing back to home...");
            this.router.navigate([""]);
        }
    }
}