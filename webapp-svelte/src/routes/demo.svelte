<script>
	import Modal from '$lib/modal.svelte';

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

	// Event savedModel di cui è stato eseguito il dispatch. In questo modo non viene catturato dal on:click
	const onSaveDispatchButtonDispatched = (e) => {
		console.log(`Dispatched event: ${JSON.stringify(e.detail)}`);
	};
</script>

<h2>Modal</h2>
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#id_modal">
	Demo modal
</button>
<Modal model={dataModel} on:click={onSaveButtonClickListener} on:savedModel={onSaveDispatchButtonDispatched}>
	<div slot="moreData">
		<p>html aggiuntivo...</p>
	</div>
</Modal>
