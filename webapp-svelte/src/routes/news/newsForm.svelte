<script>
	let errors = {};
	let formModel = {
		title: '',
		description: '',
		author: ''
	};

	function OnSubmitButtonClicked(event) {
		// const formData = new FormData(event.target);
		// const data = {};

		// for (let field in formData) {
		// 	const [key, value] = field;

		// 	// if (key === 'author' && !isNameValid(value)) {
		// 	// 	errors[key] = key + ' can only have alphabets!';
		// 	// 	continue;
		// 	// }

		// 	// if (!value) {
		// 	// 	errors[key] = key + ' is required';
		// 	// }

		// 	data[key] = value;
		// }

		console.log(formModel);
		// alert('Are you sure?');
	}

	function isNameValid(value) {
		return /^[a-zA-Z]$/.test(value);
	}
</script>

<form on:submit|preventDefault={OnSubmitButtonClicked}>
	<div class="card">
		<div class="card-body">
			<h4 class="card-title">Insert a news</h4>
			<div class="row">
				<div class="col-md-6">
					<label for="id_title" class="warning form-label">Title</label>
					<input
						id="id_title"
						name="title"
						type="text"
						bind:value={formModel.title}
						class="form-control"
					/>
					{#if errors.title}
						<p><small style="color: red"> {errors.title} </small></p>
					{/if}
				</div>
				<div class="col-md-6">
					<label for="id_author" class="form-label">Author</label>
					<input
						id="id_author"
						name="author"
						type="text"
						bind:value={formModel.author}
						class="form-control"
						pattern="^[^0-9]+$"
						title="Caratteri numeri non ammessi"
					/>
				</div>
				<div class="col-12">
					<label for="id_description" class="form-label">Description</label>
					<input
						id="id_description"
						name="description"
						type="text"
						bind:value={formModel.description}
						class="form-control"
					/>
				</div>
			</div>
			<br />
			<button class="btn btn-primary" type="submit">Save</button>
		</div>
	</div>
</form>

<style>
</style>
