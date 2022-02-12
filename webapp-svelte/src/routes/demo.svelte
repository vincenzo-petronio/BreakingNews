<script>
	import Modal from '../components/modal.svelte';

	let dataModel = {
		name: 'vincenzo',
		city: 'rome',
		telephone: 3331122444,
		subscriptionDate: new Date()
	};

	// Event propagato dal click sul button Save
	const onSaveButtonClickListener = (e) => {
		console.log(`Click sul button: ${e.target.id} - dataModel: ${JSON.stringify(dataModel)}`);
	};
</script>

<h1>Demo</h1>
<p>{dataModel.name}</p>
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#id_modal">
	Demo modal
</button>
<Modal model={dataModel} on:click={onSaveButtonClickListener}>
	<div slot="moreData">
		<p>html aggiuntivo...</p>
	</div>
</Modal>
