<script>
	import Modal from '../components/modal.svelte';

	let dataModel = {
		name: 'vincenzo',
		city: 'rome',
		telephone: 3331122444,
		subscriptionDate: new Date()
	};
</script>

<h1>Demo</h1>
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#id_modal">
	Demo modal
</button>
<Modal model={dataModel} />