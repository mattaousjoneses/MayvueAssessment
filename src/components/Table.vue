<template>
  <div class="tableContainer">
    <b-container>
      <AddModule id="modal-add" ref="addMod" @addMotionPicture="handleAdd" />
      <EditModule
        id="modal-edit"
        ref="editMod"
        @editMotionPicture="handleEdit"
      />
      <CopyModule
        id="modal-copy"
        ref="copyMod"
        @copyMotionPicture="handleCopy"
      />
      <DeleteModule
        id="modal-delete"
        ref="deleteMod"
        @deleteMotionPicture="handleDelete"
      />
    </b-container>
    <hr />
    <div style="overflow-x: auto">
      <div class="align-right">
        <b-button class="add" @click="showAddModal()">
          <i class="fas fa-plus-circle"></i>
          Add
        </b-button>
      </div>
      <table>
        <tr>
          <th @click="sort('ID')">ID</th>
          <th @click="sort('Title')">Title</th>
          <th @click="sort('Description')">Description</th>
          <th @click="sort('Release Year')">Release Year</th>
          <th>Actions</th>
        </tr>
        <tr v-for="datum in TableData" :key="datum.ID">
          <td>{{ datum.ID }}</td>
          <td>{{ datum.Title }}</td>
          <td>{{ datum.Description }}</td>
          <td>{{ datum.ReleaseYear }}</td>
          <td>
            <span>
              <i
                class="fas fa-edit"
                @click="
                  showEditModal(
                    datum.ID,
                    datum.Title,
                    datum.Description,
                    datum.ReleaseYear
                  )
                "
              ></i>
              <i
                class="far fa-copy"
                @click="
                  showCopyModal(
                    datum.ID,
                    datum.Title,
                    datum.Description,
                    datum.ReleaseYear
                  )
                "
              ></i>
              <i
                class="fas fa-trash-alt"
                style="color: darkred"
                @click="
                  showDeleteModal(
                    datum.ID,
                    datum.Title,
                    datum.Description,
                    datum.ReleaseYear
                  )
                "
              ></i>
            </span>
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
import AddModule from "./AddModule";
import EditModule from "./EditModule.vue";
import CopyModule from "./CopyModule.vue";
import DeleteModule from "./DeleteModule.vue";

export default {
  name: "Table",

  components: { AddModule, EditModule, CopyModule, DeleteModule },

  data() {
    return {
      TableData: [],
      currentSort: "",
      uri: "https://localhost:44368/api/MotionPictures",
      sortTo: "ID",
      reverse: false,
    };
  },
  methods: {
    showAddModal() {
      console.log("Showing Add Module");
      
      this.$refs.addMod.showThatAddModal();

    },

    showEditModal(id, title, desc, rY) {
      console.log("showing Edit Module");
      this.$refs.editMod.showThatEditModal(id, title, desc, rY);
    },

    showCopyModal(id, title, desc, rY) {
      console.log("showing Copy Module");
      this.$refs.copyMod.showThatCopyModal(id, title, desc, rY);
    },

    showDeleteModal(id, title, desc, rY) {
      console.log("showing Delete Module");
      this.$refs.deleteMod.showThatDeleteModal(id, title, desc, rY);
    },

    sort(sortTo) {
      if (sortTo == this.sortTo) {
        this.reverse = !this.reverse;
      } else {
        this.reverse = false;
      }

      this.sortTo=sortTo;

      this.quickSort(0, this.TableData.length - 1);

      this.$forceUpdate();
    },

    swap(leftIndex, rightIndex) {

      [this.TableData[leftIndex], this.TableData[rightIndex]] = [
        this.TableData[rightIndex],
        this.TableData[leftIndex],
      ];

      console.log("leftIndex = " + leftIndex + " rightIndex = " + rightIndex);
      console.log(
        "Swapped " +
          this.TableData[leftIndex].Title +
          " and " +
          this.TableData[rightIndex].Title
      );
    },
    partition(left, right) {
      var pivot = this.TableData[Math.floor((right + left) / 2)], //middle element
        i = left, //left pointer
        j = right; //right pointer
      console.log(
        "left pointer: " +
          left +
          " right pointer: " +
          right +
          " Math.floor((right + left) / 2) : " +
          Math.floor((right + left) / 2)
      );
      while (i <= j) {
        while (this.compareMovies(this.TableData[i], pivot)) {
          i++;
        }
        while (this.compareMovies(pivot, this.TableData[j])) {
          j--;
        }
        if (i <= j) {
          this.swap(i, j); //sawpping two elements
          i++;
          j--;
        }
      }
      return i;
    },

    quickSort(left, right) {
      var index;
      if (this.TableData.length > 1) {
        index = this.partition(left, right); //index returned from partition
        if (left < index - 1) {
          //more elements on the left side of the pivot
          this.quickSort(left, index - 1);
        }
        if (index < right) {
          //more elements on the right side of the pivot
          this.quickSort(index, right);
        }
      }
      return this.TableData;
    },


    compareMovies(movieA, movieB) {
      switch (this.sortTo) {
        case "ID":
          return (this.reverse ? movieA.ID > movieB.ID : movieA.ID < movieB.ID)

        case "Title":
          return (this.reverse ? movieA.Title > movieB.Title : movieA.Title < movieB.Title)

        case "Description":
          return (this.reverse ? movieA.Description > movieB.Description : movieA.Description < movieB.Description)

        case "Release Year":
          return (this.reverse ? movieA.ReleaseYear > movieB.ReleaseYear : movieA.ReleaseYear < movieB.ReleaseYear)

        default:
          throw "invalid sort";
      }
    },

    async handleAdd(title, desc, rY) {
      console.log(title);
      console.log(desc);
      console.log(rY);

      //Send Post to C# w/ title, desc, rY
      await fetch(this.uri, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          Title: title,
          Description: desc,
          ReleaseYear: rY,
        }),
      });

      //refresh Table w/ Get
      this.refreshTable();
    },

    async handleEdit(id, title, desc, rY) {
      console.log(id);
      console.log(title);
      console.log(desc);
      console.log(rY);

      //Send Post to C# w/ title, desc, rY
      await fetch(this.uri, {
        method: "PUT",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ID: id,
          Title: title,
          Description: desc,
          ReleaseYear: rY,
        }),
      });

      //refresh Table w/ Get
      this.refreshTable();
    },

    async handleCopy(id, title, desc, rY) {
      console.log(id);
      console.log(title);
      console.log(desc);
      console.log(rY);

      //Send Post to C# w/ title, desc, rY
      await fetch(this.uri, {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        mode: "no-cors",
        body: JSON.stringify({
          Title: title,
          Description: desc,
          ReleaseYear: rY,
        }),
      });

      //refresh Table w/ Get
      this.refreshTable();
    },

    async handleDelete(id, title, desc, rY) {
      console.log(id);
      console.log(title);
      console.log(desc);
      console.log(rY);

      //Send Post to C# w/ title, desc, rY
      await fetch(this.uri, {
        method: "DELETE",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ID: id,
          Title: title,
          Description: desc,
          ReleaseYear: rY,
        }),
      });

      //refresh Table w/ Get
      this.refreshTable();
    },

    async refreshTable() {
      this.TableData =
      console.log(await fetch(this.uri, {
        method: "GET",
        headers: {
          Accept: "application/json",
        },
      })
      .then((response) => response.json())
      );

      this.$forceUpdate();
    },
  },
  created() {
    this.TableData = [
      {
        ID: 1,
        Title: "Batman",
        Description: "About a man who's a Bat.",
        ReleaseYear: 1989,
      },
      {
        ID: 2,
        Title: "Superman",
        Description: "About a man who's just super.",
        ReleaseYear: 1978,
      },
      {
        ID: 3,
        Title: "Spiderman",
        Description: "About a man who gets bit by a spider and dies.",
        ReleaseYear: 2002,
      },
      {
        ID: 4,
        Title: "Hitman",
        Description: "About a man who released the spider.",
        ReleaseYear: 2007,
      },
      {
        ID: 5,
        Title: "Layman",
        Description: "About a man who couldn't finish a project.",
        ReleaseYear: 2022,
      },
      {
        ID: 6,
        Title: "Funnyman",
        Description: "About a man who thought this was cute.",
        ReleaseYear: 1337,
      },
      {
        ID: 7,
        Title: "Talisman",
        Description: "About a man of not.",
        ReleaseYear: 2008,
      },
    ];
    this.currentSort = "ID";
  },
};
</script>

<style>
th,
td {
  padding: 5px;
  border-bottom: 1px solid rgb(81, 86, 102);
}
i {
  padding: 2px;
}

tr:hover {
  background-color: #31333b;
}
.fas,
.far {
  cursor: pointer;
}
.fas:hover,
.far:hover {
  color: lightblue !important;
}
th:hover {
  cursor: pointer;
  color: lightblue;
}
.add {
  background-color: rgb(67, 111, 255) !important;
  color: white;
  border: none;
}
.add:hover {
  color: lightblue !important;
  cursor: pointer;
}
.align-right {
  text-align: right;
}
table {
  width: 100%;
}
.tableContainer {
  background-color: #292a31;
}
</style>
