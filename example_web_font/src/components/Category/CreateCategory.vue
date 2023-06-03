<template>
  <div class="border p-3 mt-4">
    <h2 class="text-dark">Create Category</h2>
    <hr />

    <div class="mb-3 row p-1">
      <label for="Name" class="p-0">Name</label>
      <input v-model="category.name" id="Name" class="form-control" />
    </div>

    <div class="mb-3 row p-1">
      <label for="DisplayOrder" class="p-0">Display Order</label>
      <input
        v-model="category.displayOrder"
        id="DisplayOrder"
        type="number"
        class="form-control"
      />
    </div>

    <div class="row">
      <button
        @click="createCategory"
        type="button"
        class="btn btn-dark form-control"
      >
        Create
      </button>
      <button
        @click="goBack"
        type="button"
        class="btn btn-outline-secondary form-control"
      >
        Go Back
      </button>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      category: {
        name: "",
        displayOrder: 0,
      },
    };
  },
  methods: {
    async createCategory() {
      try {
        await axios.post("https://localhost:7139/api/Category", this.category);
        this.$router.push("/category"); // redirect to the list
      } catch (error) {
        console.error(error);
      }
    },
    goBack() {
      this.$router.push("/");
    },
  },
};
</script>
